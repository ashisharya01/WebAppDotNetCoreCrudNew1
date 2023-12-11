internal interface ICustomer
{
    string Email { get; init; }
    string Firstname { get; init; }
    int ID { get; init; }
    string Lastname { get; init; }

    void Deconstruct(out int ID, out string Firstname, out string Lastname, out string Email);
    bool Equals(Customer? other);
    bool Equals(object obj);
    int GetHashCode();
    string ToString();
}