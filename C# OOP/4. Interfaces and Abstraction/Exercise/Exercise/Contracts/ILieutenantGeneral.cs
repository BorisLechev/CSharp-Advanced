﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddSoldier(ISoldier @private);
    }
}