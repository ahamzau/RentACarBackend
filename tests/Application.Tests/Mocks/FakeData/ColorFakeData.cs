using System.Collections.Generic;
using Core.Test.Application.FakeData;
using Domain.Entities;

namespace Application.Tests.Mocks.FakeData;

public class ColorFakeData : BaseFakeData<Color>
{
    public override List<Color> CreateFakeData()
    {
        var data = new List<Color>
        {
            new() { Id = 1, Name = "Blue" },
            new() { Id = 2, Name = "Red" }
        };
        return data;
    }
}
