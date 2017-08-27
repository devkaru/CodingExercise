using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using CodingExercise.DAL.Interface;
using CodingExercise.DAL.Concret;
using CodingExercise.DAL.Context;

namespace CodingExercise
{
    internal static class Setup
    {
        /// <summary>
        /// Initializes StructureMap (dependency injector) to setup our concrete database provider.
        /// </summary>
        public static void Initialize()
        {
            // Initialize our concrete database provider type.
            ObjectFactory.Initialize(x => { x.For<IRepository>().Use<MongoRepository>(); });
        }

        /// <summary>
        /// Disposes the database provider context.
        /// </summary>
        public static void Close()
        {
            if (DbContext.IsOpen)
            {
                DbContext.Current.Dispose();
            }
        }
    }
}
