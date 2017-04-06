using Microsoft.Azure.Mobile.Server;
using System;

namespace sallemService.DataObjects
{
    public class TodoItem : EntityData 
    {
       
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}