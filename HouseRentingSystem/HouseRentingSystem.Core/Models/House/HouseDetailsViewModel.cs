﻿using HouseRentingSystem.Core.Models.Agent;

namespace HouseRentingSystem.Core.Models.House;

public class HouseDetailsViewModel : HouseServiceModel
{
    public string Description { get; init; } = null!;

    public string Category { get; init; } = null!;

    public AgentServiceModel Agent { get; init; } = null!;
}
