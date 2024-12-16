using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class TrackService : ITrackService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public TrackService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Track>> GetPopularTracks()
        {
            // Пример: возвращаем первые 10 популярных треков
            return await _repositoryWrapper.Track.FindAll();
        }

        public async Task<Track> GetById(int id)
        {
            // Используем FirstOrDefault, чтобы вернуть первый элемент или null, если список пуст
            var track = await _repositoryWrapper.Track.FindByCondition(t => t.Id == id);
            return track.FirstOrDefault();
        }

        public async Task<List<Track>> GetTracksByArtist(int artistId)
        {
            return await _repositoryWrapper.Track.FindByCondition(t => t.ArtistId == artistId);
        }

        public async Task<List<Track>> GetLikedTracksByUser(int userId)
        {
            // Получаем лайкнутые треки пользователя
            var likes = await _repositoryWrapper.Like.FindByCondition(l => l.UserId == userId);
            var trackIds = likes.Select(l => l.TrackId).ToList();
            return await _repositoryWrapper.Track.FindByCondition(t => trackIds.Contains(t.Id));
        }
    }
}