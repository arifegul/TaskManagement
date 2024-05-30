using Microsoft.AspNetCore.Mvc;


namespace TaskManagement.Business.Shared
{
    public class CustomBaseController : ControllerBase
    {
        public ActionResult CreateActionResultInstance<T>(Response<T> response)
        {
			return new ObjectResult(response)
			{
				StatusCode = response.StatusCode
			};
		}
	}
}
