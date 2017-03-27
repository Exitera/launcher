﻿using Caliburn.Micro;
using _11thLauncher.Messages;

namespace _11thLauncher.ViewModels.Controls
{
    public class StatusbarViewModel : PropertyChangedBase, IHandle<StatusbarMessage>
    {
        private readonly IEventAggregator _eventAggregator;

        private string _statusText;
        public string StatusText
        {
            get
            {
                return _statusText;
            }
            set
            {
                _statusText = value;
                NotifyOfPropertyChange(() => StatusText);
            }
        }

        private bool _taskRunning;
        public bool TaskRunning
        {
            get
            {
                return _taskRunning;
            }
            set
            {
                _taskRunning = value;
                NotifyOfPropertyChange(() => TaskRunning);
            }
        }

        public StatusbarViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            StatusText = Properties.Resources.S_STATUS_READY;
        }

        public void Handle(StatusbarMessage message)
        {
            StatusText = message.Text;
            TaskRunning = message.Running;
        }
    }
}