package jp.vivion.koeto.grapheme

import android.icu.text.BreakIterator

class GraphemeCounter {
    companion object {
        @JvmStatic fun count(str: String): Int {
            val iterator = BreakIterator.getCharacterInstance()
            iterator.setText(str)
            var count = 0
            while (iterator.next() != BreakIterator.DONE) {
                count++
            }
            return count
        }
    }
}