﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public interface IMovements
    {
        Vector2 LeftMovement();
        Vector2 RightMovement();
    }
}
