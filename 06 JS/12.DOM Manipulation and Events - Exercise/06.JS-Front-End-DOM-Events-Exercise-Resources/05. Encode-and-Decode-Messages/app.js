function encodeAndDecodeMessages() {
    const buttons = Array.from(document.getElementsByTagName('button'));
    const textAreas = Array.from(document.getElementsByTagName('textarea'));
    const encodeTextArea = textAreas[0];
    const decodeTextArea = textAreas[1];
    const encodeButton = buttons[0];
    const decodeButton = buttons[1];

    encodeButton.addEventListener('click', encodeMessage);
    decodeButton.addEventListener('click', decodeMessage);


    function encodeMessage() {
      
        let textToEncode = encodeTextArea.value;
        let encodedText = '';
        for (let i = 0; i < textToEncode.length; i++) {
            let chNum = textToEncode[i].charCodeAt(0);
            encodedText += String.fromCharCode(chNum + 1);
        }
        decodeTextArea.value = encodedText;
        encodeTextArea.value = '';
        
    }

    function decodeMessage() {
        
        let textToDecode = decodeTextArea.value;
        let decodedText = '';
        for (let i = 0; i < textToDecode.length; i++) {
            let chNum = textToDecode[i].charCodeAt(0);
            decodedText += String.fromCharCode(chNum - 1);
        }
        decodeTextArea.value = decodedText;
        
        
    }
}
