﻿using System;

namespace TestRunner.Proxies
{

    class ClassInitializeAttribute : AttributeBase
    {

        public static ClassInitializeAttribute TryCreate(Attribute attribute)
        {
            return TryCreate(
                attribute,
                "Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute",
                a => new ClassInitializeAttribute(a));
        }


        ClassInitializeAttribute(Attribute attribute)
            : base(attribute)
        {
        }

    }

}
