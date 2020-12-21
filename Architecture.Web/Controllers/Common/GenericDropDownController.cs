using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.BLL.Services.Implements.LU;
using Architecture.BLL.Services.Interfaces.LU;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web.Controllers.Common
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/GenericDropDown")]
    public class GenericDropDownController : BaseController
    {

        //private readonly ICRUDService<DegreeType> degreeTypeService;
        private readonly IAddressTypeService addressTypeService;
        private readonly IAppUserStatusService userStatusService;
        private readonly IAppUserTypeService userTypeService;
        private readonly IAssetTypeService assetTypeService;
        private readonly IBankNameService bankNameService;
        private readonly IContractTypeService contractTypeService;
        private readonly ICountryNameService countryNameService;
        private readonly IDegreeTypeService degreeTypeService;
        private readonly IDocumentTypeService documentTypeService;
        private readonly IEyeColorService eyeColorService;
        private readonly IGenderService genderService;
        private readonly IHouseCategoryService houseCategoryService;
        private readonly IHouseTypeService houseTypeService;
        private readonly IIncomeTypeService incomeTypeService;
        private readonly IInsuranceTypeService insuranceTypeService;
        private readonly IISEEClassTypeService iseeClassTypeService;
        private readonly IJobDeliveryTypeService jobdeliveryTypeService;
        private readonly IJobTypeService jobTypeService;


        private readonly ILoanInterestTypeService loandInterestTypeService;
        private readonly ILoanStatusTypeService loanStatusTypeService;
        private readonly IMaritalStatusService maritalStatusService;
        private readonly IMotiveTypeService motiveTypeService;
        private readonly INationalIdTypeService nationalIdTypeService;
        private readonly INationalityService nationalityService;
        private readonly IOccupationPositionService occupationPositionService;
        private readonly IOccupationPositionTypeService occupationPositionTypeService;
        private readonly IOccupationTypeService occupationTypeService;
        
        private readonly IOwnerTypeService ownerTypeService;
        private readonly IRelationTypeService relationTypeService;
        private readonly IResidenceScopeService residenceScopeService;
        private readonly ISectionNameService sectionNameService;
        private readonly IWorkerTypeService workerTypeService;


        public GenericDropDownController(
            IAddressTypeService _addressTypeService,
            IAppUserStatusService _userStatusService,
            IAppUserTypeService _userTypeService,
            IAssetTypeService _assetTypeService,
            IBankNameService _bankNameService,
            IContractTypeService _contractTypeService,
            ICountryNameService _countryNameService,
            IDegreeTypeService _degreeTypeService,
            IDocumentTypeService _documentTypeService,
            IEyeColorService _eyeColorService,
            IGenderService _genderService,
            IHouseCategoryService _houseCategoryService,
            IHouseTypeService _houseTypeService,
            IIncomeTypeService _incomeTypeService,
            IInsuranceTypeService _insuranceTypeService,
            IISEEClassTypeService _iseeClassTypeService,
            IJobDeliveryTypeService _jobdeliveryTypeService,
            IJobTypeService _jobTypeService,
            ILoanInterestTypeService _loandInterestTypeService,
            ILoanStatusTypeService _loanStatusTypeService,
            IMaritalStatusService _maritalStatusService,
            IMotiveTypeService _motiveTypeService,
            INationalIdTypeService _nationalIdTypeService,
            INationalityService _nationalityService,
            IOccupationPositionService _occupationPositionService,
            IOccupationPositionTypeService _occupationPositionTypeService,
            IOccupationTypeService _occupationTypeService,
            IOwnerTypeService _ownerTypeService,
            IRelationTypeService _relationTypeService,
            IResidenceScopeService _residenceScopeService,
            ISectionNameService _sectionNameService,
            IWorkerTypeService _workerTypeService
            )
        {
            addressTypeService = _addressTypeService;
            userStatusService = _userStatusService;
            userTypeService = _userTypeService;
            assetTypeService = _assetTypeService;
            bankNameService = _bankNameService;
            contractTypeService = _contractTypeService;
            countryNameService = _countryNameService;
            degreeTypeService = _degreeTypeService;
            documentTypeService = _documentTypeService;
            eyeColorService = _eyeColorService;
            genderService = _genderService;
            houseCategoryService = _houseCategoryService;
            houseTypeService = _houseTypeService;
            incomeTypeService = _incomeTypeService;
            insuranceTypeService = _insuranceTypeService;
            iseeClassTypeService = _iseeClassTypeService;
            jobdeliveryTypeService = _jobdeliveryTypeService;
            jobTypeService = _jobTypeService;
            loandInterestTypeService = _loandInterestTypeService;
            loanStatusTypeService = _loanStatusTypeService;
            maritalStatusService = _maritalStatusService;
            motiveTypeService = _motiveTypeService;
            nationalIdTypeService = _nationalIdTypeService;
            nationalityService = _nationalityService;
            occupationPositionService = _occupationPositionService;
            occupationPositionTypeService = _occupationPositionTypeService;
            occupationTypeService = _occupationTypeService;

            ownerTypeService = _ownerTypeService;
            relationTypeService = _relationTypeService;
            residenceScopeService = _residenceScopeService;
            sectionNameService = _sectionNameService;
            workerTypeService = _workerTypeService;
        }        

        [HttpGet("AddressType")]
        public async Task<IActionResult> GetAddressType()
        {
            try
            {
                var result = await addressTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        } 
        [HttpGet("UserStatus")]
        public async Task<IActionResult> GetAppUserStatus()
        {
            try
            {
                var result = await userStatusService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("UserType")]
        public async Task<IActionResult> GetAppUserType()
        {
            try
            {
                var result = await userTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
         [HttpGet("AssetType")]
        public async Task<IActionResult> GetAssetType()
        {
            try
            {
                var result = await assetTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("BankName")]
        public async Task<IActionResult> GetBankName()
        {
            try
            {
                var result = await bankNameService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("ContractType")]
        public async Task<IActionResult> GetContractType()
        {
            try
            {
                var result = await contractTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("CountryName")]
        public async Task<IActionResult> GetCountryName()
        {
            try
            {
                var result = await countryNameService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("DegreeName")]
        public async Task<IActionResult> GetDegreeName()
        {
            try
            {
                var result = await degreeTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("DocumentType")]
        public async Task<IActionResult> GetDocumentType()
        {
            try
            {
                var result = await documentTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("EyeColor")]
        public async Task<IActionResult> GetEyeColor()
        {
            try
            {
                var result = await eyeColorService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("Gender")]
        public async Task<IActionResult> GetGender()
        {
            try
            {
                var result = await genderService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
         [HttpGet("HouseCategory")]
        public async Task<IActionResult> GetHouseCategory()
        {
            try
            {
                var result = await houseCategoryService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("HouseType")]
        public async Task<IActionResult> GetHouseType()
        {
            try
            {
                var result = await houseTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("IncomeType")]
        public async Task<IActionResult> GetIncomeType()
        {
            try
            {
                var result = await incomeTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("InsuranceType")]
        public async Task<IActionResult> GetInsuranceType()
        {
            try
            {
                var result = await insuranceTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("ISEEClassType")]
        public async Task<IActionResult> GetISEEClassType()
        {
            try
            {
                var result = await iseeClassTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("JobDeliveryType")]
        public async Task<IActionResult> GetJobDeliveryType()
        {
            try
            {
                var result = await jobdeliveryTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("JobType")]
        public async Task<IActionResult> GetJobType()
        {
            try
            {
                var result = await jobTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("LoanInterestType")]
        public async Task<IActionResult> GetLoanInterestType()
        {
            try
            {
                var result = await loandInterestTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("LoanStatusType")]
        public async Task<IActionResult> GetLoanStatusType()
        {
            try
            {
                var result = await loanStatusTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("MaritalStatus")]
        public async Task<IActionResult> GetMaritalStatus()
        {
            try
            {
                var result = await maritalStatusService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("MotiveTypeService")]
        public async Task<IActionResult> GetMotiveTypeService()
        {
            try
            {
                var result = await motiveTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("NationalIdType")]
        public async Task<IActionResult> GetNationalIdType()
        {
            try
            {
                var result = await nationalIdTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("Nationality")]
        public async Task<IActionResult> GetNationality()
        {
            try
            {
                var result = await nationalityService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("OccupationPosition")]
        public async Task<IActionResult> GetOccupationPosition()
        {
            try
            {
                var result = await occupationPositionService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("OccupationPositionType")]
        public async Task<IActionResult> GetOccupationPositionType()
        {
            try
            {
                var result = await occupationPositionTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("OccupationType")]
        public async Task<IActionResult> GetOccupationType()
        {
            try
            {
                var result = await occupationTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        
        [HttpGet("OwnerType")]
        public async Task<IActionResult> GetOwnerType()
        {
            try
            {
                var result = await ownerTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("RelationType")]
        public async Task<IActionResult> GetRelationType()
        {
            try
            {
                var result = await relationTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        } 
        [HttpGet("ResidenceScope")]
        public async Task<IActionResult> GetResidenceScope()
        {
            try
            {
                var result = await residenceScopeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        
        [HttpGet("SectionName")]
        public async Task<IActionResult> GetSectionName()
        {
            try
            {
                var result = await sectionNameService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("WorkerType")]
        public async Task<IActionResult> GetWorkerType()
        {
            try
            {
                var result = await workerTypeService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

    }
}
