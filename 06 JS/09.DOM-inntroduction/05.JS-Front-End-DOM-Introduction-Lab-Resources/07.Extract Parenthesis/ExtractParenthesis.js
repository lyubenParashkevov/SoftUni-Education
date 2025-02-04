function extract(content) {
    
    const contentText = document.getElementById('content');

    const matches = contentText.textContent.matchAll(/\(([^)]+)\)/g);

    const text = Array.from(matches)
    .map(match => match[1])
    .join('; ');

    return(text);
}