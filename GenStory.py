import tensorflow as tf
import numpy as np
import sys
pred_model= tf.keras.models.load_model(r'C:\Users\micha\Story Gen\saved_model/reddot.h5')
vocab = ['\t', '\n', ' ', '!', '"', '#', '$', '%', '&', "'", '(', ')', '*', '+', ',', '-', '.', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?', '@', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '[', '\\', ']', '^', '_', '`', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{', '|', '}', '~']

char2int = {c:i for i, c in enumerate(vocab)}

int2char = np.array(vocab)



def generate_text(tmp,chars,model, start_string):
    
    print('Generating with seed: "' + start_string + '"')
  
    num_generate = chars
    input_eval = [char2int[s] for s in start_string]
    input_eval = tf.expand_dims(input_eval, 0)
    

    text_generated = []

    temperature = tmp #tmp goes between 0 to 1.0
    model.reset_states()
    for i in range(num_generate):
        predictions = model(input_eval)
        predictions = tf.squeeze(predictions, 0)
        predictions = predictions / temperature
        predicted_id = tf.random.categorical(predictions, num_samples=1)[-1,0].numpy()
        input_eval = tf.expand_dims([predicted_id], 0)
        text_generated.append(int2char[predicted_id])
    return (start_string + ''.join(text_generated))

userInput = sys.argv[1]
start_string_US = "<sos> " + userInput

if(float(sys.argv[2]) == 0.0):
    inputTemp = 0.5
else:
    inputTemp = float(sys.argv[2])


if(float(sys.argv[3]) == 0.0):
    storyLen = 5000
    #3000 only takes a bit(15secs) to work
else:
    storyLen = int(sys.argv[3])


output = (generate_text(inputTemp,storyLen,pred_model, start_string=start_string_US))
output = output.replace("<nl>","\n")
output = output.replace("<sos>","")

text_file = open(r"C:\Users\micha\source\repos\StoryGenForm\sample.txt", "w")
n = text_file.write(output)
text_file.close()

print(output)

