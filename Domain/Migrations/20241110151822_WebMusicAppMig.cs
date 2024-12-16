using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class WebMusicAppMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Genres__3213E83F927BA21F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password_hash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83FCAB1C574", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    advertiser_id = table.Column<int>(type: "int", nullable: false),
                    image_path = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    link = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Advertis__3213E83F71C63927", x => x.id);
                    table.ForeignKey(
                        name: "FK__Advertise__adver__797309D9",
                        column: x => x.advertiser_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Listeners",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    preferences = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Listener__3213E83FCA830C34", x => x.id);
                    table.ForeignKey(
                        name: "FK__Listeners__id__4316F928",
                        column: x => x.id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    bio = table.Column<string>(type: "text", nullable: true),
                    donation_account = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Musician__3213E83FE9CFF1B1", x => x.id);
                    table.ForeignKey(
                        name: "FK__Musicians__id__3E52440B",
                        column: x => x.id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_read = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3213E83F7B32F9B0", x => x.id);
                    table.ForeignKey(
                        name: "FK__Notificat__user___160F4887",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    payment_method = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payments__3213E83F09C85D0E", x => x.id);
                    table.ForeignKey(
                        name: "FK__Payments__user_i__7F2BE32F",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    session_token = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    expires_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sessions__3213E83F4A51A48F", x => x.id);
                    table.ForeignKey(
                        name: "FK__Sessions__user_i__123EB7A3",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    listener_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Playlist__3213E83F1683C018", x => x.id);
                    table.ForeignKey(
                        name: "FK__Playlists__liste__6FE99F9F",
                        column: x => x.listener_id,
                        principalTable: "Listeners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    artist_id = table.Column<int>(type: "int", nullable: false),
                    release_date = table.Column<DateOnly>(type: "date", nullable: false),
                    cover_image_path = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Albums__3213E83FAEFAFB04", x => x.id);
                    table.ForeignKey(
                        name: "FK__Albums__artist_i__4CA06362",
                        column: x => x.artist_id,
                        principalTable: "Musicians",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    listener_id = table.Column<int>(type: "int", nullable: false),
                    musician_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Donation__3213E83F1CB31849", x => x.id);
                    table.ForeignKey(
                        name: "FK__Donations__liste__5CD6CB2B",
                        column: x => x.listener_id,
                        principalTable: "Listeners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Donations__music__5DCAEF64",
                        column: x => x.musician_id,
                        principalTable: "Musicians",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    listener_id = table.Column<int>(type: "int", nullable: false),
                    musician_id = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subscrip__3213E83FB62C61AF", x => x.id);
                    table.ForeignKey(
                        name: "FK__Subscript__liste__03F0984C",
                        column: x => x.listener_id,
                        principalTable: "Listeners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Subscript__music__04E4BC85",
                        column: x => x.musician_id,
                        principalTable: "Musicians",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    artist_id = table.Column<int>(type: "int", nullable: false),
                    album_id = table.Column<int>(type: "int", nullable: true),
                    genre_id = table.Column<int>(type: "int", nullable: false),
                    release_date = table.Column<DateOnly>(type: "date", nullable: false),
                    file_path = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tracks__3213E83F2918E1BB", x => x.id);
                    table.ForeignKey(
                        name: "FK__Tracks__album_id__52593CB8",
                        column: x => x.album_id,
                        principalTable: "Albums",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Tracks__artist_i__5165187F",
                        column: x => x.artist_id,
                        principalTable: "Musicians",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Tracks__genre_id__534D60F1",
                        column: x => x.genre_id,
                        principalTable: "Genres",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    track_id = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__3213E83F6CE91A73", x => x.id);
                    table.ForeignKey(
                        name: "FK__Comments__track___6754599E",
                        column: x => x.track_id,
                        principalTable: "Tracks",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Comments__user_i__66603565",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    track_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Likes__3213E83FD3F64019", x => x.id);
                    table.ForeignKey(
                        name: "FK__Likes__track_id__6C190EBB",
                        column: x => x.track_id,
                        principalTable: "Tracks",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Likes__user_id__6B24EA82",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Listens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    listener_id = table.Column<int>(type: "int", nullable: false),
                    track_id = table.Column<int>(type: "int", nullable: false),
                    listened_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Listens__3213E83F80DCE753", x => x.id);
                    table.ForeignKey(
                        name: "FK__Listens__listene__619B8048",
                        column: x => x.listener_id,
                        principalTable: "Listeners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Listens__track_i__628FA481",
                        column: x => x.track_id,
                        principalTable: "Tracks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Playlist_Tracks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playlist_id = table.Column<int>(type: "int", nullable: false),
                    track_id = table.Column<int>(type: "int", nullable: false),
                    added_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Playlist__3213E83F1095E5D7", x => x.id);
                    table.ForeignKey(
                        name: "FK__Playlist___playl__74AE54BC",
                        column: x => x.playlist_id,
                        principalTable: "Playlists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Playlist___track__75A278F5",
                        column: x => x.track_id,
                        principalTable: "Tracks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    track_id = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Promotio__3213E83F95D0FAD3", x => x.id);
                    table.ForeignKey(
                        name: "FK__Promotion__track__5812160E",
                        column: x => x.track_id,
                        principalTable: "Tracks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    track_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ratings__3213E83FAB47B0E3", x => x.id);
                    table.ForeignKey(
                        name: "FK__Ratings__track_i__1BC821DD",
                        column: x => x.track_id,
                        principalTable: "Tracks",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Ratings__user_id__1AD3FDA4",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    track_id = table.Column<int>(type: "int", nullable: false),
                    listens = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    likes = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    donations = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0m),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Statisti__3213E83FC1A94DD5", x => x.id);
                    table.ForeignKey(
                        name: "FK__Statistic__track__09A971A2",
                        column: x => x.track_id,
                        principalTable: "Tracks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_advertiser_id",
                table: "Advertisements",
                column: "advertiser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_artist_id",
                table: "Albums",
                column: "artist_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_track_id",
                table: "Comments",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_user_id",
                table: "Comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_listener_id",
                table: "Donations",
                column: "listener_id");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_musician_id",
                table: "Donations",
                column: "musician_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Genres__72E12F1B5168EA2F",
                table: "Genres",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_user_track_like",
                table: "Likes",
                columns: new[] { "user_id", "track_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_track_id",
                table: "Likes",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_Listens_listener_id",
                table: "Listens",
                column: "listener_id");

            migrationBuilder.CreateIndex(
                name: "IX_Listens_track_id",
                table: "Listens",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_user_id",
                table: "Notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_user_id",
                table: "Payments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "idx_playlist_track",
                table: "Playlist_Tracks",
                columns: new[] { "playlist_id", "track_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_Tracks_track_id",
                table: "Playlist_Tracks",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_listener_id",
                table: "Playlists",
                column: "listener_id");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_track_id",
                table: "Promotions",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_track_id",
                table: "Ratings",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_user_id",
                table: "Ratings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_user_id",
                table: "Sessions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Sessions__E598F5C8192ECA75",
                table: "Sessions",
                column: "session_token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_track_id",
                table: "Statistic",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_listener_id",
                table: "Subscriptions",
                column: "listener_id");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_musician_id",
                table: "Subscriptions",
                column: "musician_id");

            migrationBuilder.CreateIndex(
                name: "idx_artist_id",
                table: "Tracks",
                column: "artist_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_album_id",
                table: "Tracks",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_genre_id",
                table: "Tracks",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "idx_email",
                table: "Users",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "idx_username",
                table: "Users",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E61642790C607",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__F3DBC572F2049C10",
                table: "Users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Listens");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Playlist_Tracks");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Statistic");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Listeners");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
