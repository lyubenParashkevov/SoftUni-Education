namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            int produserId = 9;
            string albumInfo = ExportAlbumsInfo(context, produserId);
            Console.WriteLine(albumInfo);
            Console.WriteLine("-----------------------------------------------------------------------------");

            int duration = 4;
            string result = ExportSongsAboveDuration(context, duration);
            Console.WriteLine(result);

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {

            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    AlbumSongs = a.Songs
                        .Select(s => new
                        {
                            s.Id,
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriterName = s.Writer.Name,
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriterName)
                        .ToList(),
                    //AlbumPrice = a.Songs.Sum(s => s.Price)
                    AlbumPrice = a.Price,
                })
                .ToList();

            albums = albums.OrderByDescending(a => a.AlbumPrice).ToList();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int index = 1;
                foreach (var s in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{index++}");
                    sb.AppendLine($"---SongName: {s.SongName}");
                    sb.AppendLine($"---Price: {s.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {s.SongWriterName}");
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds( duration );
            StringBuilder sb = new StringBuilder();
            int index = 1;

            var songs = context.Songs
                .Where(s => s.Duration > timeSpan)
                .Select(s => new
                {
                    
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    AlbumProducer = (s.Album != null) ? (s.Album.Producer != null ?
                                    s.Album.Producer.Name : null) : (null),
                    Duration = s.Duration.ToString("c"),
                    Performers = s.SongPerformers
                        .Select(sp => new
                        {
                            FirstName = sp.Performer.FirstName,
                            LastName = sp.Performer.LastName,
                        })
                        .OrderBy(p => p.FirstName)
                        .ThenBy(p => p.LastName)
                        .ToList(),
                
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToList();

            foreach (var s in songs)
            {
                sb.AppendLine($"-Song #{index++}");
                sb.AppendLine($"---SongName: {s.SongName}");
                sb.AppendLine($"---Writer: {s.WriterName}");

                foreach (var p in s.Performers)
                {
                    sb.AppendLine($"---Performer: {p.FirstName} {p.LastName}");
                }

                sb.AppendLine($"---AlbumProducer: {s.AlbumProducer}");
                sb.AppendLine($"---Duration: {s.Duration}");

            }

            return sb.ToString().TrimEnd();

        }


    }
}
