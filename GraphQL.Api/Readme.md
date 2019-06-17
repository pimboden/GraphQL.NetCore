http://localhost:5091/graphql/

# Select 
{
  properties {
    name
    payments {
      id
      value,
      dateCreated
    }
  }
}

# Select with parameter
{
  properties {
    name
    payments(last:1) {
      id
      value,
      dateCreated
    }
  }
}
{
  property(id:3) {
    id,
    name
    payments(last:1) {
      id
      value,
      dateCreated
    }
  }
}

# Mutations
##Add to query vaiables in http://localhost:5091/graphql/
{
  "property":{
    "nane":"Patrick's mansion",
    "street":"Spring garden",
    "city":"Stans",
    "family":"Imboden"
  }
}