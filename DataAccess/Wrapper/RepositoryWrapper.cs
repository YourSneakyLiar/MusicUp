using Domain.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repositories;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private WebMusicAppContext _repoContext;

        private IUserRepository _user;
        private IAlbumRepository _album;
        private ITrackRepository _track;
        private IPlaylistRepository _playlist;
        private IGenreRepository _genre;
        private ILikeRepository _like;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public IAlbumRepository Album
        {
            get
            {
                if (_album == null)
                {
                    _album = new AlbumRepository(_repoContext);
                }
                return _album;
            }
        }

        public ITrackRepository Track
        {
            get
            {
                if (_track == null)
                {
                    _track = new TrackRepository(_repoContext);
                }
                return _track;
            }
        }

        public IPlaylistRepository Playlist
        {
            get
            {
                if (_playlist == null)
                {
                    _playlist = new PlaylistRepository(_repoContext);
                }
                return _playlist;
            }
        }

        public IGenreRepository Genre
        {
            get
            {
                if (_genre == null)
                {
                    _genre = new GenreRepository(_repoContext);
                }
                return _genre;
            }
        }

        public ILikeRepository Like
        {
            get
            {
                if (_like == null)
                {
                    _like = new LikeRepository(_repoContext);
                }
                return _like;
            }
        }

        public RepositoryWrapper(WebMusicAppContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}