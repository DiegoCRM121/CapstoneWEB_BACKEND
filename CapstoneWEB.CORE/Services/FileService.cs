using CapstoneWEB.CORE.DTOs;
using CapstoneWEB.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneWEB.CORE.Services
{
    public class FileService: IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<IEnumerable<FileDTO>> GetAll()
        {
            var files = await _fileRepository.GetAll();
            var filesDTO = new List<FileDTO>();
            //Pasar todas las categorias
            //al dto (IEnumerable<Category> ---> IEnumerable<CategoryDescription>

            foreach (var file in files)
            {
                var fileDTO = new FileDTO();
                fileDTO.IdFile = file.IdFile; 
                fileDTO.FileName = file.FileName;
                fileDTO.FileType = file.FileType;

                filesDTO.Add(fileDTO);
            }
            return filesDTO;
        }

        public async Task<bool> Insert(FileInsertDTO fileInsert)
        {
            var file = new CapstoneWEB.CORE.Entities.File();
            file.FileName = fileInsert.FileName;
            file.FileType = fileInsert.FileType;
            return await _fileRepository.Insert(file);
        }
    }
}
