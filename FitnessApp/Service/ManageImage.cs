using FitnessApp.Data;
using FitnessApp.Interfaces;
using FitnessApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FitnessApp.Service
{
    public class ManageImage : IManageImage
    {
        private readonly DataContext dataContext;

        public ManageImage(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        private string GetFilePath(string fileName)
        {
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            string filePath = Path.Combine(uploadsFolder, fileName);
            return filePath;
        }

        public async Task<string> UploadFile(IFormFile  _File, Guid userId)
        {
            string FileName = "";
            try
            {
                FileInfo _FileInfo = new FileInfo(_File.FileName);
                FileName = _File.FileName + "_" + DateTime.Now.Ticks.ToString() + _FileInfo.Extension;
                var _GetFilePath = GetFilePath(FileName);
                using (var _FileStream = new FileStream(_GetFilePath, FileMode.Create))
                {
                    await _File.CopyToAsync(_FileStream);
                }

                var user = await dataContext.Users.FirstOrDefaultAsync(d => d.Id == userId);
                user.ProfilePictures = _GetFilePath;

                dataContext.Users.Update(user);
                await dataContext.SaveChangesAsync();
                return FileName;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<(byte[], string, string)> DownloadFile(string FileName)
        {
            try
            {
                var _GetFilePath = GetFilePath(FileName);
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(_GetFilePath, out var _ContentType))
                {
                    _ContentType = "application/octet-stream";
                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(_GetFilePath);
                return (_ReadAllBytesAsync, _ContentType, Path.GetFileName(_GetFilePath));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

