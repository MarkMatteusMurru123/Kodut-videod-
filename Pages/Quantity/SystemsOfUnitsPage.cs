﻿using System.Collections.Generic;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Quantity
{
   public class SystemsOfUnitsPage : CommonPage<ISystemsOfUnitsRepository, SystemOfUnits,SystemOfUnitsView, SystemOfUnitsData>
   {
       protected internal SystemsOfUnitsPage(ISystemsOfUnitsRepository r) : base(r)
       {
           PageTitle = "System Of Units";
           
       }
       public override string ItemId => Item.Id;
       
       protected internal override string GetPageUrl() => "/Quantity/SystemsOfUnits";
       protected internal override SystemOfUnits ToObject(SystemOfUnitsView view)
       {
           return SystemOfUnitsViewFactory.Create(view);
       }

       protected internal override SystemOfUnitsView ToView(SystemOfUnits obj)
       {
           return SystemOfUnitsViewFactory.Create(obj);
       }
   } 
    
}
