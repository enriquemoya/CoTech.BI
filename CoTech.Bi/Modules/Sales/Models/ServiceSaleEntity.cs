﻿using System;
using System.ComponentModel.DataAnnotations;
using CoTech.Bi.Core.Companies.Models;
using CoTech.Bi.Modules.Clients.Models;
using CoTech.Bi.Modules.Services.Models;

namespace CoTech.Bi.Modules.Sales.Models{
    public class ServiceSaleEntity{
        public long Id{ set; get; }
        [Required]
        public long ServiceId{ set; get; }
        [Required]
        public long ClientId{ set; get; }
        [Required]
        public float Price{ set; get; }
        [Required]
        public int Quantity{ set; get; }
        [Required]
        public DateTime Date{ set; get; }
        [Required]
        public long CompanyId{ set; get; }
        
        public bool iva{ set; get; }
        
        public CompanyEntity Company{ set; get; }
        public ServiceEntity Service{ set; get; }
        public ClientEntity Client{ set; get; }
        
        public DateTime CreatedAt{ set; get; }
        public DateTime? DeletedAt{ set; get; }
    }
}