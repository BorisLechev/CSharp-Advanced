﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Logger.Models.Contracts
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        void EnsureDirectoryAndFileExist();

        string GetCurrentPath();
    }
}
