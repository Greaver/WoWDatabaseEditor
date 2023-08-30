using Prism.Ioc;
using WDE.Common.Disposables;
using WDE.Common.Managers;
using WDE.Common.Services;
using WDE.Common.Services.MessageBox;
using WDE.Common.Tasks;
using WDE.Common.Utils;
using WDE.Module.Attributes;

namespace WDE.MapRenderer
{
    [AutoRegister]
    [SingleInstance]
    public class GameViewService : IGameView, IGameViewService
    {
        private readonly Lazy<IDocumentManager> documentManager;
        private readonly IMessageBoxService messageBoxService;
        private readonly IContainerProvider provider;
        private List<Func<IContainerProvider, IGameModule>> modules = new();

        public IEnumerable<Func<IContainerProvider, IGameModule>> Modules => modules;
        public event Action<Func<IContainerProvider, IGameModule>>? ModuleRegistered;
        public event Action<Func<IContainerProvider, IGameModule>>? ModuleRemoved;

        public GameViewService(Lazy<IDocumentManager> documentManager,
            IMessageBoxService messageBoxService,
            IContainerProvider provider)
        {
            this.documentManager = documentManager;
            this.messageBoxService = messageBoxService;
            this.provider = provider;
        }
        
        public IDisposable RegisterGameModule(Func<IContainerProvider, IGameModule> gameModule)
        {
            modules.Add(gameModule);
            ModuleRegistered?.Invoke(gameModule);
            return new ActionDisposable(() =>
            {
                var indexOf = modules.IndexOf(gameModule);
                ModuleRemoved?.Invoke(gameModule);
                modules[indexOf] = modules[^1];
                modules.RemoveAt(modules.Count - 1);
            });
        }

        public async Task<Game> Open()
        {
            if (!GlobalApplication.Supports3D)
            {
                await messageBoxService.ShowDialog(new MessageBoxFactory<bool>()
                    .SetTitle("Can't load game view")
                    .SetMainInstruction("Can't load the game view")
                    .SetContent(
                        "Unfortunately due to a change in the UI framework, the 3D view stopped working on Windows. " +
                        "I am working on a fix, but for now you can use the 3D view on Linux or MacOS. Sorry.\n\n\n" +
                        "If you reaaally want to enable it, add --wgl flag to the command line arguments. This will force enable 3D in Windows, " +
                        "but it tends to be unstable (or unusable completely).")
                    .WithOkButton(false)
                    .Build());
                return null!;
            }
            var existing = documentManager.Value.TryFindDocumentEditor<GameViewModel>(x => true);
            if (existing == null)
            {
                existing = provider.Resolve<GameViewModel>();
                documentManager.Value.OpenDocument(existing);
            }
            else
                documentManager.Value.ActiveDocument = existing;
            return existing.CurrentGame;
        }

        void IGameViewService.Open()
        {
            Open().ListenErrors();
        }
    }
}