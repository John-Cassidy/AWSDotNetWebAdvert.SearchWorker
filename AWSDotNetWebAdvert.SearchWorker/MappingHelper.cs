using AdvertApi.Models.Messages;
using System;

namespace AWSDotNetWebAdvert.SearchWorker {
    public static class MappingHelper
    {
        public static AdvertType Map(AdvertConfirmedMessage message) {
            var doc = new AdvertType {
                Id = message.Id,
                Title = message.Title,
                CreationDateTime = DateTime.UtcNow
            };
            return doc;
        }
    }
}
