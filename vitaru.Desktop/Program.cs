// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Desktop;

namespace vitaru.Desktop
{
    public static class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            return osu.Desktop.Program.Main(args);
        }
    }
}
