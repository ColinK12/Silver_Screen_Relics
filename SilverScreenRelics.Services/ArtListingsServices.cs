using ScreenRelics.Data;
using SilverScreenRelics.Data.Entities;
using SilverScreenRelics.Models.ArtListingsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Services
{
    public class ArtListingsServices
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();
        //Create
        public bool CreateArtListing(ArtListingsCreate model)
        {
            ArtListings entity = new ArtListings
            {
                RelicId = model.RelicId,
                ArtItemDescription = model.ArtItemDescription,

            };

            _dbContext.Art_Listings.Add(entity);
            return _dbContext.SaveChanges() == 1;

        }

        //Get All
        public List<ArtListingsDetails> GetAllArtListings()
        {
            var artListingsEnteties = _dbContext.Art_Listings.ToList();
            var artListings = artListingsEnteties.Select(l => new ArtListingsDetails
            {
                RelicId = l.RelicId,
                ArtItemDescription = l.ArtItemDescription,
            }).ToList();
            return artListings;
        }

        //Get By Id
        public ArtListingsDetails GetArtListingById(int artListingId)
        {
            var artListingsEntity = _dbContext.Art_Listings.Find(artListingId);
            if (artListingsEntity == null)
                return null;
            var detail = new ArtListingsDetails
            {
                RelicId = artListingsEntity.RelicId,
                ArtItemDescription = artListingsEntity.ArtItemDescription,
            };
            return detail;
        }
        //ArtItem Update
        public bool UpdateArtListings(ArtListings model)
        {
            var artItemEntity = _dbContext.Art_Listings.SingleOrDefault(e => e.RelicId == model.RelicId);

            artItemEntity.ArtItemTitle = model.ArtItemTitle;
            artItemEntity.ArtItemDescription = model.ArtItemDescription;

            return _dbContext.SaveChanges() == 1;
        }

        //ArtItem Delete
        public bool DeleteArtItem(int id)
        {
            var artItemEntity = _dbContext.Art_Listings.SingleOrDefault(e => e.RelicId == id);

            _dbContext.Art_Listings.Remove(artItemEntity);
            return _dbContext.SaveChanges() == 1;

        }
    }
}
