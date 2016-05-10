﻿using System;
using Gamma.ViewModels;

namespace Gamma.Views
{
    /// <summary>
    /// CodeBehind для UserEditViewWindow
    /// </summary>
    public partial class UserEditView
    {
        public UserEditView(UserEditMessage msg)
        {
            var viewModel = msg.UserID == null ? new UserEditViewModel(msg.GammaBase) : new UserEditViewModel((Guid)msg.UserID, msg.GammaBase);
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
