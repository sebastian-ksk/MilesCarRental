﻿namespace MilesCarRental.API.Utils
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        // Cambio de 'object' a 'T' para hacer uso efectivo del tipo genérico
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse(bool success = true, string message = "", T data = default, List<string> errors = null)
        {
            Success = success;
            Message = message;
            Data = data; 
            Errors = errors ?? new List<string>();
        }
    }

}
