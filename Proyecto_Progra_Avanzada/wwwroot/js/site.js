// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const numberList = [
    1, 4, 7, 10, 13, 16, 19, 21, 23, 25, 27, 29, 32, 35, 37, 39, 41, 43, 46, 48,
    50, 52, 54, 56, 58, 60, 63, 66, 69, 72, 74, 77, 79, 81, 83, 84, 86, 88, 90,
    92, 95, 96, 98, 100, 102, 104, 106, 107, 108, 109, 111, 113, 114, 115, 116,
    118, 120, 122, 123, 124, 125, 126, 127, 128, 129, 131, 132, 133, 137, 138,
    140, 142, 143, 144, 145, 146, 147
];

function capturarPokemon() {
    // Generate a random index within the range of numberList length
    const randomIndex = Math.floor(Math.random() * numberList.length);

    // Get the number from numberList at the random index
    const pokemonID = numberList[randomIndex];

    // Assign the number to the hidden input field in the form
    document.getElementById('PokemonID').value = pokemonID;

    // Submit the form
    document.getElementById('pokemonForm').submit();
}