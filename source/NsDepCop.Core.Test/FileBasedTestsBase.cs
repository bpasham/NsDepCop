﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codartis.NsDepCop.Core.Test
{
    /// <summary>
    /// Abstract base class for test classes that manipulate test files.
    /// </summary>
    public abstract class FileBasedTestsBase
    {
        protected string GetTestFilePath(string filename)
        {
            var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Assert.IsNotNull(assemblyDirectory);

            const string namespacePrefix = "Codartis.NsDepCop.Core.Test.";
            var namespacePostfix = GetType().FullName.Remove(0, namespacePrefix.Length).Replace('.', '\\');

            var path = Path.Combine(assemblyDirectory, namespacePostfix, filename);
            return path;
        }

        protected static void Rename(string fromFilename, string toFilename)
        {
            if (File.Exists(fromFilename))
            {
                if (File.Exists(toFilename))
                    throw new InvalidOperationException($"Cannot rename '{fromFilename}' to '{toFilename}' because it already exists.");

                File.Move(fromFilename, toFilename);
            }
        }

        protected static void Delete(string filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);
        }
    }
}