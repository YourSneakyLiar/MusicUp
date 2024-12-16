using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class WebMusicAppContext : DbContext
{
    public WebMusicAppContext()
    {
    }

    public WebMusicAppContext(DbContextOptions<WebMusicAppContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=LAPTOP-886FNGF4\\MSSQLSERVER02;Database=WebMusicApp;User Id=sa;Password=password_123;TrustServerCertificate=True;");
               // b => b.MigrationsAssembly("DataAccess")); // Указываем сборку для миграций
        }
    }



    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Listen> Listens { get; set; }

    public virtual DbSet<Listener> Listeners { get; set; }

    public virtual DbSet<Musician> Musicians { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<PlaylistTrack> PlaylistTracks { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Statistic> Statistics { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advertisement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Advertis__3213E83F71C63927");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdvertiserId).HasColumnName("advertiser_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_path");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Advertiser).WithMany(p => p.Advertisements)
                .HasForeignKey(d => d.AdvertiserId)
                .HasConstraintName("FK__Advertise__adver__797309D9");
        });

        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Albums__3213E83FAEFAFB04");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.CoverImagePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cover_image_path");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Artist).WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK__Albums__artist_i__4CA06362");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3213E83F6CE91A73");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.TrackId).HasColumnName("track_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Track).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__track___6754599E");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Comments__user_i__66603565");
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Donation__3213E83F1CB31849");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ListenerId).HasColumnName("listener_id");
            entity.Property(e => e.MusicianId).HasColumnName("musician_id");

            entity.HasOne(d => d.Listener).WithMany(p => p.Donations)
                .HasForeignKey(d => d.ListenerId)
                .HasConstraintName("FK__Donations__liste__5CD6CB2B");

            entity.HasOne(d => d.Musician).WithMany(p => p.Donations)
                .HasForeignKey(d => d.MusicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Donations__music__5DCAEF64");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genres__3213E83F927BA21F");

            entity.HasIndex(e => e.Name, "UQ__Genres__72E12F1B5168EA2F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Likes__3213E83FD3F64019");

            entity.HasIndex(e => new { e.UserId, e.TrackId }, "idx_user_track_like").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.TrackId).HasColumnName("track_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Track).WithMany(p => p.Likes)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__track_id__6C190EBB");

            entity.HasOne(d => d.User).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Likes__user_id__6B24EA82");
        });

        modelBuilder.Entity<Listen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Listens__3213E83F80DCE753");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ListenedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("listened_at");
            entity.Property(e => e.ListenerId).HasColumnName("listener_id");
            entity.Property(e => e.TrackId).HasColumnName("track_id");

            entity.HasOne(d => d.Listener).WithMany(p => p.Listens)
                .HasForeignKey(d => d.ListenerId)
                .HasConstraintName("FK__Listens__listene__619B8048");

            entity.HasOne(d => d.Track).WithMany(p => p.Listens)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Listens__track_i__628FA481");
        });

        modelBuilder.Entity<Listener>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Listener__3213E83FCA830C34");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Preferences).HasColumnName("preferences");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Listener)
                .HasForeignKey<Listener>(d => d.Id)
                .HasConstraintName("FK__Listeners__id__4316F928");
        });

        modelBuilder.Entity<Musician>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Musician__3213E83FE9CFF1B1");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Bio)
                .HasColumnType("text")
                .HasColumnName("bio");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DonationAccount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("donation_account");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Musician)
                .HasForeignKey<Musician>(d => d.Id)
                .HasConstraintName("FK__Musicians__id__3E52440B");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83F7B32F9B0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("is_read");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__user___160F4887");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3213E83F09C85D0E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("payment_method");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Payments__user_i__7F2BE32F");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Playlist__3213E83F1683C018");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ListenerId).HasColumnName("listener_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Listener).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.ListenerId)
                .HasConstraintName("FK__Playlists__liste__6FE99F9F");
        });

        modelBuilder.Entity<PlaylistTrack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Playlist__3213E83F1095E5D7");

            entity.ToTable("Playlist_Tracks");

            entity.HasIndex(e => new { e.PlaylistId, e.TrackId }, "idx_playlist_track").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("added_at");
            entity.Property(e => e.PlaylistId).HasColumnName("playlist_id");
            entity.Property(e => e.TrackId).HasColumnName("track_id");

            entity.HasOne(d => d.Playlist).WithMany(p => p.PlaylistTracks)
                .HasForeignKey(d => d.PlaylistId)
                .HasConstraintName("FK__Playlist___playl__74AE54BC");

            entity.HasOne(d => d.Track).WithMany(p => p.PlaylistTracks)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Playlist___track__75A278F5");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promotio__3213E83F95D0FAD3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.TrackId).HasColumnName("track_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Track).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK__Promotion__track__5812160E");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ratings__3213E83FAB47B0E3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Rating1).HasColumnName("rating");
            entity.Property(e => e.TrackId).HasColumnName("track_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Track).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ratings__track_i__1BC821DD");

            entity.HasOne(d => d.User).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Ratings__user_id__1AD3FDA4");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sessions__3213E83F4A51A48F");

            entity.HasIndex(e => e.SessionToken, "UQ__Sessions__E598F5C8192ECA75").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("datetime")
                .HasColumnName("expires_at");
            entity.Property(e => e.SessionToken)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("session_token");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sessions__user_i__123EB7A3");
        });

        modelBuilder.Entity<Statistic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Statisti__3213E83FC1A94DD5");

            entity.ToTable("Statistic");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Donations)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("donations");
            entity.Property(e => e.Likes)
                .HasDefaultValue(0)
                .HasColumnName("likes");
            entity.Property(e => e.Listens)
                .HasDefaultValue(0)
                .HasColumnName("listens");
            entity.Property(e => e.TrackId).HasColumnName("track_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Track).WithMany(p => p.Statistics)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK__Statistic__track__09A971A2");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrip__3213E83FB62C61AF");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.ListenerId).HasColumnName("listener_id");
            entity.Property(e => e.MusicianId).HasColumnName("musician_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Listener).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.ListenerId)
                .HasConstraintName("FK__Subscript__liste__03F0984C");

            entity.HasOne(d => d.Musician).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.MusicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subscript__music__04E4BC85");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tracks__3213E83F2918E1BB");

            entity.HasIndex(e => e.ArtistId, "idx_artist_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlbumId).HasColumnName("album_id");
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_path");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Album).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK__Tracks__album_id__52593CB8");

            entity.HasOne(d => d.Artist).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK__Tracks__artist_i__5165187F");

            entity.HasOne(d => d.Genre).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tracks__genre_id__534D60F1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FCAB1C574");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E61642790C607").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572F2049C10").IsUnique();

            entity.HasIndex(e => e.Email, "idx_email");

            entity.HasIndex(e => e.Username, "idx_username");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
