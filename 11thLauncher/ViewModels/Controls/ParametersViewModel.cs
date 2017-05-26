﻿using _11thLauncher.Model.Parameter;
using Caliburn.Micro;
using _11thLauncher.Messages;
using System;
using System.Linq;

namespace _11thLauncher.ViewModels.Controls
{
    public class ParametersViewModel : PropertyChangedBase, IHandle<LoadProfileMessage>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ParameterManager _parameterManager;

        private BindableCollection<LaunchParameter> _parameters;
        public BindableCollection<LaunchParameter> Parameters
        {
            get { return _parameters; }
            set
            {
                _parameters = value;
                NotifyOfPropertyChange();
            }
        }

        public ParametersViewModel(IEventAggregator eventAggregator, ParameterManager parameterManager)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _parameterManager = parameterManager;

            Parameters = _parameterManager.Parameters;
        }

        #region Message handling

        public void Handle(LoadProfileMessage message)
        {
            foreach (var parameter in Parameters)
            {
                var profileParameter = message.Parameters.FirstOrDefault(parameter.Equals);
                if (profileParameter != null)
                {
                    parameter.IsEnabled = profileParameter.IsEnabled;
                    parameter.SelectedValue = profileParameter.SelectedValue;
                } else 
                {
                    parameter.IsEnabled = false;
                    parameter.SelectedValue = null;
                }
            }
        }

        #endregion
    }
}