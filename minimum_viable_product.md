# Minimum Viable Product

The user must have following experience when opening the application for the first time.

1. Open the application and be greeted with an empty landing page.
    
    * The landing page should include a header with '+' (plus) button to the left.
    * A small message in the middle of the screen and arrow pointing to the '+' (plus) button in the header should capture the user's attention. 

</br> 

2. Clicking the '+' (plus) button should open a large popup window with the following elements.

    * Name (string), input field.
    * Birth date (date-time), input field.
    * Gender (enum: male | female), input field.
    * Confirmation button titled 'Confirm' to the left.
    * Cancel button button titled 'Cancel' to the right.

</br>

3. If the user clicks the 'Cancel' button, then they arrive at point 1. above.

</br>

4. If the user clicks the 'Confirm' button, the following happens.

    * A new row should appear in landing page. The row should consist of four elements: 
        * name (text) (top left),
        * age (number xx.xx) (rolling down slowly like a vintage flip clock) (bottom left)
        * countdown to time of death (date-time yyyy-mm-dd hh:mm:ss) (counting down every second) (upper right), 
        * date of time of death (date-time) (lower right).

</br>

5. If the user adds a new row, the the row should appear the bottom and then it should be possible to reorder the rows by hold clicking and dragging.

</br>

6. The user should be to delete a row by swiping to the left or right of the row.

</br>

7. The user should be able to click on a gear icon in the header to the right, where a new page appears with some documentation about the application and the authors. The header changes so there is no '+' (plus) button or gear icon, instead an arrow back appears to the left to go back.