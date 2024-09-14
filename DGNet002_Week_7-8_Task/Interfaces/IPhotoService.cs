using CloudinaryDotNet.Actions;

namespace DGNet002_Week_7_8_Task.Interfaces
{
	public interface IPhotoService
	{
		Task<ImageUploadResult> AddPhotoAsync(IFormFile imageFile);
		Task<DeletionResult> DeletePhotoAsync(string publicId);
		Task<ImageUploadResult> UpdatePhotoAsync(IFormFile imageFile, string publicId);

	}
}
