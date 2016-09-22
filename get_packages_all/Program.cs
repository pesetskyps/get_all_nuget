using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanNugetSharp;
using NuGet;

namespace get_packages_all
{
    class Program
    {
        static void Main(string[] args)
        {
            //Connect to the official package repository
            //var uri = "http://nuget.plex-dev.projects.epam.com/api/";
            var uri = "https://packages.plex.com/nuget";
            var uri2 = "https://packages.plex.com/api/v2/package";
            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository(uri);

            //Get the list of all NuGet packages with ID 'EntityFramework'       
            List<IPackage> packages = repo.GetPackages().ToList();
            var downloader = new PlexPackageDownloader((Uri)new Uri(uri2), "d:\\packages");
            foreach (var package in packages)
            {
                Console.WriteLine(package.GetFullName());
                downloader.Download(package);
                //Console.ReadLine();hell
                //new chagnes here
            }
            
        }
    }
}
