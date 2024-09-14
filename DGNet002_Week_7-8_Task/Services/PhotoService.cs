using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DGNet002_Week_7_8_Task.Helpers;
using DGNet002_Week_7_8_Task.Interfaces;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.Extensions.Options;

namespace DGNet002_Week_7_8_Task.Services
{
	public class PhotoService : IPhotoService
	{
		private readonly Cloudinary _cloudinary;
		public PhotoService(IOptions<CloudinarySettings> config) 
		{
			var account = new Account(
				config.Value.CloudName,
				config.Value.ApiKey,
				config.Value.ApiSecret
				);
			_cloudinary = new Cloudinary(account);
		}
		public async Task<ImageUploadResult> AddPhotoAsync(IFormFile imageFile)
		{
			var uploadResult = new ImageUploadResult();

			if (imageFile != null && imageFile.Length > 0)
			{
				try
				{
					using var stream = imageFile.OpenReadStream();

					var uploadParams = new ImageUploadParams
					{
						File = new FileDescription(imageFile.FileName, stream),
						Transformation = new Transformation().Width(500).Crop("fill").Gravity("face")
					};
					uploadResult = await _cloudinary.UploadAsync(uploadParams);
				}
				catch (Exception ex)
				{
					throw new Exception("Image upload failed, ex");
				}
			}
			else
			{
				throw new ArgumentException("No image file provided.");
			}
			return uploadResult;
		}

		public async Task<DeletionResult> DeletePhotoAsync(string publicId)
		{
			var deleteParams = new DeletionParams(publicId);

			var result = await _cloudinary.DestroyAsync(deleteParams);

			return result;
		}

		public async Task<ImageUploadResult> UpdatePhotoAsync(IFormFile imageFile, string publicId)
		{
			var uploadResult = new ImageUploadResult();

			using var stream = imageFile.OpenReadStream();
			var uploadParams = new ImageUploadParams()
			{
				File = new FileDescription(imageFile.FileName, stream),
				Transformation = new Transformation().Width(500).Crop("fill").Gravity("face"),
				PublicId = publicId,
				Overwrite = true,
			};

			uploadResult = await _cloudinary.UploadAsync(uploadParams);
			return uploadResult;
		}
	}
}
