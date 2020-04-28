using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Domain.Dapper.Models
{
    public class TestTableModel
    {
        [HiddenInput(DisplayValue = false)]
        public int MenuIdentity { get; set; }
        public string Menu_Id { get; set; }
        public string Menu_Name { get; set; }
        public string Parent_MenuId { get; set; }
        public string User_Roll { get; set; }
        public int User_Auth { get; set; }
        public int User_Duty { get; set; }
        public string Menu_Area { get; set; }
        public string Menu_Controller { get; set; }
        public string Menu_Action { get; set; }
        public string Use_Yn { get; set; }
        public int Sort_Order { get; set; }
        public DateTime Created_Date { get; set; }
        public string Css_Class { get; set; }
    }
}
