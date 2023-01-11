const pokémon = Object.freeze([
    { "id": 1, "name": "Bulbasaur", "types": ["poison", "grass"] },
    { "id": 5, "name": "Charmeleon", "types": ["fire"] },
    { "id": 9, "name": "Blastoise", "types": ["water"] },
    { "id": 12, "name": "Butterfree", "types": ["bug", "flying"] },
    { "id": 16, "name": "Pidgey", "types": ["normal", "flying"] },
    { "id": 23, "name": "Ekans", "types": ["poison"] },
    { "id": 24, "name": "Arbok", "types": ["poison"] },
    { "id": 25, "name": "Pikachu", "types": ["electric"] },
    { "id": 37, "name": "Vulpix", "types": ["fire"] },
    { "id": 52, "name": "Meowth", "types": ["normal"] },
    { "id": 63, "name": "Abra", "types": ["psychic"] },
    { "id": 67, "name": "Machamp", "types": ["fighting"] },
    { "id": 72, "name": "Tentacool", "types": ["water", "poison"] },
    { "id": 74, "name": "Geodude", "types": ["rock", "ground"] },
    { "id": 87, "name": "Dewgong", "types": ["water", "ice"] },
    { "id": 98, "name": "Krabby", "types": ["water"] },
    { "id": 115, "name": "Kangaskhan", "types": ["normal"] },
    { "id": 122, "name": "Mr. Mime", "types": ["psychic"] },
    { "id": 133, "name": "Eevee", "types": ["normal"] },
    { "id": 144, "name": "Articuno", "types": ["ice", "flying"] },
    { "id": 145, "name": "Zapdos", "types": ["electric", "flying"] },
    { "id": 146, "name": "Moltres", "types": ["fire", "flying"] },
    { "id": 148, "name": "Dragonair", "types": ["dragon"] }
]);


const pkmnIdsDiv3 = pokémon.filter( p => p.id % 3 === 0)
console.log(pkmnIdsDiv3)

const pkmnTypeFire = pokémon.filter(p => p.types.includes("fire"))
console.log(pkmnTypeFire)

const pkmn2Types = pokémon.filter(p => p.types.length > 1)
console.log(pkmn2Types)

const pkmnNames = pokémon.map(p => p.name)
console.log(pkmnNames)

const pkmnNamesWithIdGreaterThan99 = pokémon.filter(pId => pId.id > 99).map(pName => pName.name)
console.log(pkmnNamesWithIdGreaterThan99)

const pkmnNamesPoison = pokémon.filter(pType => pType.types.includes("poison") && pType.types.length === 1).map(pName => pName.name)
console.log(pkmnNamesPoison)

const pkmnFirstFlyType = pokémon.filter(p => p.types.length > 1).filter(p => p.types.includes("flying")).map(p => p.types[0])
console.log(pkmnFirstFlyType)

const normalPkmnCount = pokémon.filter(p => p.types.includes("normal")).length
console.log(normalPkmnCount)