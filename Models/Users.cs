//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gamma.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public Users()
        {
            this.Docs = new HashSet<Docs>();
            this.UserPrintNames = new HashSet<UserPrintNames>();
            this.Places = new HashSet<Places>();
        }
    
        public System.Guid UserID { get; set; }
        public System.Guid RoleID { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public Nullable<System.DateTime> PassChange { get; set; }
        public Nullable<bool> PassMustChange { get; set; }
        public bool Exports { get; set; }
        public bool DBAdmin { get; set; }
        public Nullable<bool> ProgramAdmin { get; set; }
        public byte ShiftID { get; set; }
    
        public virtual ICollection<Docs> Docs { get; set; }
        public virtual Roles Roles { get; set; }
        public virtual ICollection<UserPrintNames> UserPrintNames { get; set; }
        public virtual ICollection<Places> Places { get; set; }
    }
}
