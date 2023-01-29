namespace banko;

public class Card {

    public string pin = ""; // "0123"
    public Account account;

    public Card(Account account){
        this.account = account;
    }

    public bool hasPin()
    {
        if(pin != "")
        {
            return true;
        }
        return false;
    }

    public bool createPin(string pin)
    {
        if(pin != "")
        {
            this.pin = pin;
            return true;
        }
        return false;
    }

}
