using Flurl.Http;
using TaskManagement.Infrastructure.Shared;

namespace TaskManagement.Infrastructure.APIs
{
    public static class TaskManagementAPIs
    {
        static readonly string ipAddress = "localhost";

        public static async Task<T> GetUserById<T>(int id)
        {
            var response = await $"https://{ipAddress}:44398/api/user/getUserById?id={id}".GetJsonAsync<ResponseInfra<T>>();

            return response.Data;
        }

        public static async Task<T> GetAllRole<T>()
        {
            var response = await $"https://{ipAddress}:44398/api/role/getAllRole".GetJsonAsync<ResponseInfra<T>>();

            return response.Data;
        }

        public static async Task<T> GetTaskById<T>(int id)
        {
            var response = await $"https://{ipAddress}:44398/api/task/getTaskById?id={id}".GetJsonAsync<ResponseInfra<T>>();

            return response.Data;
        }

        public static async Task<T> GetAllTask<T>()
        {
            var response = await $"https://{ipAddress}:44398/api/task/getAllTask".GetJsonAsync<ResponseInfra<T>>();

            return response.Data;
        }
    }
}
