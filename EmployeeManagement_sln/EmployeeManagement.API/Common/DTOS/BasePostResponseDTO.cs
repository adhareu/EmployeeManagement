namespace EmployeeManagement.API.Common.DTOS
{
    public record BasePostResponseDto<TKey, TEntity>
    where TKey : struct
    where TEntity : class
    {
        public TKey Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public TEntity? Entity { get; set; }
    }
}
