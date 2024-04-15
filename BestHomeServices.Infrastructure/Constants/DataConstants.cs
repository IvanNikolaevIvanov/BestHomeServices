namespace BestHomeServices.Infrastructure.Constants
{
    public static class DataConstants
    {
       
        // Specialist entity data constants
        
        public const int SpecialistFirstNameMaxLength = 20;
        public const int SpecialistFirstNameMinLength = 2;

        public const int SpecialistLastNameMaxLength = 20;
        public const int SpecialistLastNameMinLength = 2;

        public const int SpecialistPhoneNumberMaxLength = 15;
        public const int SpecialistPhoneNumberMinLength = 7;

        public const int SpecialistDescriptionMaxLength = 500;
        public const int SpecialistDescriptionMinLength = 50;

        public const int SpecialistImageUrlMaxLength = 2000;

        public const string SpecialistCategoryIdMinimum = "0";
        public const string SpecialistCategoryIdMaximum = "10000";

        public const string SpecialistCityIdMinimum = "0";
        public const string SpecialistCityIdMaximum = "10000";


        // Category entity data constants

        public const int CategoryTitleMaxLength = 50;
        public const int CategoryTitleMinLength = 3;

        public const int CategoryDescriptionMaxLength = 500;
        public const int CategoryDescriptionMinLength = 10;

        public const int CategoryImageUrlMaxLength = 2000;

        // City entity data constants

        public const int CityNameMaxLength = 50;
        public const int CityNameMinLength = 3;

        // Client entity data constants

        public const int ClientNameMaxLength = 50;
        public const int ClientNameMinLength = 5;

        public const int ClientAddressMaxLength = 150;
        public const int ClientAddressMinLength = 15;

        public const int ClientPhoneNumberMaxLength = 15;
        public const int ClientPhoneNumberMinLength = 5;
    }
}
