/*
 * Created by:	Joshua Gibbs
 * Crested on:	October 13, 2017
 * 
 * Modified by:
 * Modified on:
 * 
 * This interface provides a what is needed for a script that controls a guage.
 */
public interface GaugeController
{
	/* 
	 * The input it the value that the calling script want to change the gauge by.
	 * Ideally, the output would be true if the gauge was changed
	 * and false if the guage was not able to be changed 
	 * (i.e.: The passed changeAmount would take the current value of the guage outside of the max or min value of the guage.).
	 */
	bool ModifyValue (float changeAmount);
}
