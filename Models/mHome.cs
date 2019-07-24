using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
    public class mHome
    {
        public mUser vmUser;
        public mOrder vmOrder;
        public mCopen aCopen;
        public mCopen vmCopen;
        public mAd vmAd;
        public mRating vRating;
        public List<mAd>  aAd;
        public List<mCategory> aCategory;
        public List<mSlider> aSlider;
        public List<mAd> aSpecialOffer;
        public List<mAd> aRestaurantCofes;
        public List<mAd> aArtTheater;
        public List<mAd> aEducational;
        public List<mAd> aSportRecreation;
        public List<mAd> aHealthMedicine;
        public List<mAd> aBeautyCosmetics;
        public List<mAd> aServices;
        public List<mAd> aTourTravel;
        public List<mAd> aCommodity;
        public List<mAd> aLastMoment;
        public List<mAd> aTodayOffer;
        public List<mAd> aMostVisit;
        public List<mCategory> aSubGroup;
        public List<mAdImg> aSpecialOfferImg;
        public List<mAdImg> aRestaurantCofesImg;
        public List<mAdImg> aArtTheaterImg;
        public List<mAdImg> aEducationalImg;
        public List<mAdImg> aSportRecreationImg;
        public List<mAdImg> aHealthMedicineImg;
        public List<mAdImg> aBeautyCosmeticsImg;
        public List<mAdImg> aServicesImg;
        public List<mAdImg> aTourTravelImg;
        public List<mAdImg> aCommodityImg;
        public List<mAdImg> aLastMomentImg;
        public List<mAdImg> aTodayOfferImg;
        public List<mAdImg> aMostVisitImg;
        public List<mAdImg> aAdImg;
        public List<mCity>  aCity;
        public int act_type { get; set; }
        public int? pLang { get; set; }
        public int? counter { get; set; }
        public string pError { get; set; }
        public string pSuccess { get; set; }
        public List<mComment> aComment;
    }
}