using System;
using DctTestTask.Models.DTOs;
using DctTestTask.Repositories.Abstract;
using DctTestTask.ViewModels.Abstract;

namespace DctTestTask.Models.Events;

public class ViewChangedEventArgs : EventArgs
{
    public ViewType NextPage { get; set; }
    
    public object Data { get; set; }
}