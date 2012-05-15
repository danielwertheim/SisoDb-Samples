using System;
using System.IO;

namespace Examples.Ex02Interfaces
{
    public class InterfaceExample : Example
    {
        public override void Run()
        {
            var photo = new Photo();
            photo.Load(@"Penguins.jpg");

            using(var session = Db.BeginSession())
            {
                session.Insert<IPhoto>(photo);

                var fetchedAsPhoto = session.GetByIdAs<IPhoto, Photo>(photo.Id);
                Console.Out.WriteLine("fetchedAsPhoto.Name = {0}", fetchedAsPhoto.Name);
                Console.Out.WriteLine("fetchedAsPhoto.Path = {0}", fetchedAsPhoto.Path);
                Console.Out.WriteLine("fetchedAsPhoto.Stream.Length = {0}", fetchedAsPhoto.Stream.Length);

                fetchedAsPhoto.Load();

                Console.WriteLine("------------------------------");
                Console.Out.WriteLine("fetchedAsPhoto.Stream.Length = {0}", fetchedAsPhoto.Stream.Length);
                

                Console.WriteLine("------------------------------");
                var fetchedAsPhotoInfo = session.GetByIdAs<IPhoto, PhotoInfo>(photo.Id);
                Console.Out.WriteLine("fetchedAsPhotoInfo.Name = {0}", fetchedAsPhotoInfo.Name);
                Console.Out.WriteLine("fetchedAsPhotoInfo.Path = {0}", fetchedAsPhotoInfo.Path);
            }
        }
    }

    public interface IPhoto
    {
        Guid Id { get; set; }

        string Name { get; }

        string Path { get; }
    }

    public class Photo : IPhoto
    {
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Path { get; private set; }

        public MemoryStream Stream { get; private set; }

        public Photo()
        {
            Stream = new MemoryStream();
        }

        public void Load()
        {
            Load(Path);
        }

        public void Load(string path)
        {
            Name = System.IO.Path.GetFileName(path);
            Path = path;
            Stream = new MemoryStream(File.ReadAllBytes(path));
        }
    }

    public class PhotoInfo
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
    }
}