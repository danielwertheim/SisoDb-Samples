using System;
using System.Diagnostics;
using System.IO;
using SisoDb;

namespace Examples.Ex03Image
{
    public class ImageExample : Example
    {
        public override void Run()
        {
            var image = new Image();
            image.Load(@"Penguins.jpg");
            image.Tags = new[] { "penguins", "ice", "cold" };

            using(var session = Db.BeginSession())
            {
                session.Insert(image);

                var fetched = session.Query<Image>().Where(i => i.Name == "Penguins.jpg").Single();

                Console.Out.WriteLine("fetched.Name = {0}", fetched.Name);
                Console.Out.WriteLine("fetched.Buff.Length = {0}", fetched.Buff.Length);

                var fetchedByTags = session.Query<Image>().Where(i => i.Tags.QxAny(t => t == "ice")).Single();
                
                Console.WriteLine("------------------------------");
                Console.Out.WriteLine("fetchedByTags.Name = {0}", fetchedByTags.Name);
                Console.Out.WriteLine("fetchedByTags.Buff.Length = {0}", fetchedByTags.Buff.Length);

                //SAVE and OPEN
                var newFileName = string.Format(@"{0}.jpg", fetched.Id.ToString("D"));
                File.WriteAllBytes(newFileName, fetched.Buff);

                Process.Start(newFileName);
            } 
        }
    }

    [Serializable]
    public class Image
    {
        private MemoryStream _content;

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string[] Tags { get; set; }

        public byte[] Buff
        {
            get { return _content.ToArray(); }
            private set { _content = new MemoryStream(value); }
        }

        public Image()
        {
            _content = new MemoryStream();
        }

        public void Load(string path)
        {
            Name = Path.GetFileName(path);
            Buff = File.ReadAllBytes(path);
        }
    }
}