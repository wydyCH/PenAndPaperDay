using System;
using System.Collections.Generic;
using System.Linq;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.DTO.RestDto;
using PenAndPaperDay.Data.Repositories;

namespace PenAndPaperDay.Service.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public bool DeleteTag(int id)
        {
            if (id == 0)
                throw new ArgumentException("Empty id", nameof(id));

            var tagDto = _tagRepository.GetById(id);
            if (tagDto == null || tagDto.Id == 0)
                throw new ArgumentException("No tag with Id found", nameof(id));

            return _tagRepository.Delete(tagDto);
        }

        public TagResult GetTag(int id)
        {
            if (id==0)
                throw new ArgumentException("Empty id", nameof(id));

            TagDto tagDto = _tagRepository.GetById(id);
            if(tagDto == null)
                throw new ArgumentException("Invalid tag id", nameof(id));

            return TagParse(tagDto);
        }

        public IList<TagResult> GetTags()
        {
            //ignore language first version
            IList<TagDto> tags = _tagRepository.GetTags();

            return tags.Select(tag => TagParse(tag)).ToList();
        }

        public TagResult SaveTag(TagResult tagResult)
        {
            if (tagResult == null || tagResult.TagForm == null)
                throw new ArgumentNullException("No TagForm send");

            if (string.IsNullOrEmpty(tagResult.TagForm.Name))
                throw new ArgumentException("Empty Name", nameof(tagResult.TagForm.Name));

            var tagDto = TagParse(tagResult);

            if (string.IsNullOrEmpty(tagResult.TagForm.Id) || tagResult.TagForm.Id == "0")
            {
                tagDto.Id = 0;
                tagDto = _tagRepository.Insert(tagDto);
            }
            else
            {
                tagDto.Id = int.Parse(tagResult.TagForm.Id);
                tagDto = _tagRepository.Update(tagDto);
            }

            return TagParse(tagDto);
        }

        private TagResult TagParse(TagDto tagDto)
        {
            TagResult tagResult = new TagResult
            {
                TagForm = new TagForm()
            };

            tagResult.TagForm.Id = tagDto.Id.ToString();
            tagResult.TagForm.Name = tagDto.Name;
            tagResult.TagForm.Symbol = tagDto.Symbol;

            return tagResult;
        }

        private TagDto TagParse(TagResult tagResult)
        {
            TagDto tagDto = new TagDto
            {
                Id = int.Parse(tagResult.TagForm.Id),

                Name = tagResult.TagForm.Name,
                Symbol = tagResult.TagForm.Symbol
            };

            return tagDto;
        }
    }
}
