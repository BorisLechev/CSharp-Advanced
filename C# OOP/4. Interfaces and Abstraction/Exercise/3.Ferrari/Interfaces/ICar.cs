using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Ferrari.Interfaces
{
    public interface ICar
    {
        string Model { get; }

        string DriverName { get; }

        string Brakes();

        string Gas();
    }
}
