﻿using System;
using EquipmentRental.Domain.Models;
using System.Collections.Generic;

namespace EquipmentRental.Repository
{
    public interface IEquipementRepository
    {
        IList<Equipment> GetAll();
        Equipment Get(int id);
    }
}
