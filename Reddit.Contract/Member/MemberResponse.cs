﻿namespace Reddit.Contract.Member;
public class MemberResponse
{
    public Guid Id { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }
}
