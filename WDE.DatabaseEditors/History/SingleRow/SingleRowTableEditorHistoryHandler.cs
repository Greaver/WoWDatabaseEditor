﻿using System;
using System.Collections.Generic;
using WDE.Common.History;
using WDE.DatabaseEditors.ViewModels.SingleRow;
using WDE.MVVM.Observable;

namespace WDE.DatabaseEditors.History.SingleRow
{
    public class SingleRowTableEditorHistoryHandler : HistoryHandler, IDisposable
    {
        private readonly SingleRowDbTableEditorViewModel viewModel;
        private IDisposable? disposable;

        private HashSet<string> keys;

        public SingleRowTableEditorHistoryHandler(SingleRowDbTableEditorViewModel viewModel)
        {
            this.viewModel = viewModel;
            keys = new HashSet<string>(viewModel.TableDefinition.GroupByKeys);
            BindTableData();
        }

        public IDisposable BulkEdit(string name) => WithinBulk(name);
        
        public void Dispose()
        {
            UnbindTableData();
        }

        private void BindTableData()
        {
            disposable = viewModel.Entities.ToStream(false).SubscribeAction(e =>
            {
                if (e.Type == CollectionEventType.Add)
                {
                    e.Item.OnAction += OnAction;
                    PushAction(new DatabaseEntityAddedHistoryAction(e.Item, e.Index, viewModel));
                }
                else if (e.Type == CollectionEventType.Remove)
                {
                    PushAction(new DatabaseEntityRemovedHistoryAction(e.Item, e.Index, viewModel));
                    e.Item.OnAction -= OnAction;
                }
            });
        }

        private void OnAction(IHistoryAction action)
        {
            if (action is IDatabaseFieldHistoryAction fieldChanged)
            {
                if (keys.Contains(fieldChanged.Property))
                    return;
            }
            PushAction(action);
        }
        
        private void UnbindTableData()
        {
            foreach (var e in viewModel.Entities)
                e.OnAction -= OnAction;
            disposable?.Dispose();
            disposable = null;
        }
    }
}