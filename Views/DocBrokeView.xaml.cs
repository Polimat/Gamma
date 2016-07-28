﻿using System;
using Gamma.ViewModels;

namespace Gamma.Views
{
    /// <summary>
    /// Логика взаимодействия для DocBrokeView.xaml
    /// </summary>
    public partial class DocBrokeView
    {
        public DocBrokeView(Guid docId, Guid? productId = null)
        {
            DataContext = new DocBrokeViewModel(docId, productId);
            InitializeComponent();
        }
    }
}
